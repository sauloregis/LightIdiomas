function exibirAlerta(mensagem, tipo) {
    Swal.fire({
        title: mensagem,
        icon: tipo,
        confirmButtonText: 'OK'
    });
}

/* Todas as interações com elementos DOM ficam dentro do DOMContentLoaded */
document.addEventListener('DOMContentLoaded', function () {
    const estadoSelect = document.getElementById("estadoSelect");
    const cidadeSelect = document.getElementById("cidadeSelect");

    if (estadoSelect && cidadeSelect) {
        estadoSelect.addEventListener("change", function () {
            var estadoId = this.value;
            cidadeSelect.innerHTML = '<option value="">Carregando...</option>';

            fetch('/CadastrarCliente/ObterCidadesPorEstado?estadoId=' + estadoId)
                .then(response => response.json())
                .then(data => {
                    cidadeSelect.innerHTML = '<option value="">Selecione a Cidade</option>';
                    data.forEach(cidade => {
                        cidadeSelect.innerHTML += `<option value="${cidade.value}">${cidade.text}</option>`;
                    });
                });
        });
    }

    const cpf = document.getElementById('CPF');
    const rg = document.getElementById('RG');
    const tel = document.getElementById('telefone');
    const email = document.querySelector('input[type="email"]');

    /* máscaras e listeners */
    function maskCPFInput(e) {
        const input = e.target;
        let v = input.value.replace(/\D/g, '').slice(0, 11);
        v = v.replace(/(\d{3})(\d)/, '$1.$2');
        v = v.replace(/(\d{3})(\d)/, '$1.$2');
        v = v.replace(/(\d{3})(\d{1,2})$/, '$1-$2');
        input.value = v;
    }

    function maskRGInput(e) {
        const input = e.target;
        let v = input.value.replace(/\D/g, '').slice(0, 9);
        v = v.replace(/(\d{2})(\d)/, '$1.$2');
        v = v.replace(/(\d{3})(\d)/, '$1.$2');
        v = v.replace(/(\d{3})(\d)$/, '$1-$2');
        input.value = v;
    }

    function maskTelefoneInput(e) {
        const input = e.target;
        let v = input.value.replace(/\D/g, '').slice(0, 11);
        if (v.length > 10) {
            v = v.replace(/(\d{2})(\d{5})(\d{4})/, '($1) $2-$3');
        } else {
            v = v.replace(/(\d{2})(\d{4})(\d{0,4})/, '($1) $2' + (v.length > 6 ? '-$3' : ''));
            v = v.replace(/-undefined$/, '');
        }
        input.value = v;
    }

    function maskEmailInput(e) {
        const input = e.target;
        input.value = input.value.trim().toLowerCase();
    }

    if (cpf) {
        cpf.setAttribute('inputmode', 'numeric');
        cpf.setAttribute('maxlength', '14');
        cpf.addEventListener('input', maskCPFInput);
        cpf.addEventListener('blur', function () { cpf.value = cpf.value.trim(); });
    }

    if (rg) {
        rg.setAttribute('inputmode', 'numeric');
        rg.setAttribute('maxlength', '12');
        rg.addEventListener('input', maskRGInput);
        rg.addEventListener('blur', function () { rg.value = rg.value.trim(); });
    }

    if (tel) {
        tel.setAttribute('inputmode', 'tel');
        tel.setAttribute('maxlength', '15');
        tel.addEventListener('input', maskTelefoneInput);
        tel.addEventListener('blur', function () { tel.value = tel.value.trim(); });
    }

    if (email) {
        email.setAttribute('inputmode', 'email');
        email.addEventListener('blur', maskEmailInput);
    }

    /* validações existentes no submit */
    const form = document.querySelector("form");
    if (form) {
        form.addEventListener("submit", function (e) {
            let cpfVal = (cpf || {}).value || "";
            let rgVal = (rg || {}).value || "";
            let telefoneVal = (tel || {}).value || "";

            if (!validarCPF(cpfVal)) {
                exibirAlerta("CPF inválido!", "error");
                e.preventDefault();
                cpf && cpf.focus();
                return;
            }

            if (!validarRG(rgVal)) {
                exibirAlerta("RG inválido! Verifique se contém somente números e tem 8 ou 9 dígitos.", "error");
                e.preventDefault();
                rg && rg.focus();
                return;
            }

            if (!validarTelefone(telefoneVal)) {
                exibirAlerta("Telefone inválido! Use o DDD + número (10 ou 11 dígitos).", "error");
                e.preventDefault();
                tel && tel.focus();
                return;
            }
        });
    }
});

/* funções de validação (mantidas fora do DOMContentLoaded) */
function validarCPF(cpf) {
    cpf = (cpf || '').replace(/[^\d]+/g, '');
    if (cpf.length !== 11 || /^(\d)\1+$/.test(cpf)) return false;
    let soma = 0, resto;
    for (let i = 1; i <= 9; i++) soma += parseInt(cpf.substring(i - 1, i), 10) * (11 - i);
    resto = (soma * 10) % 11; if (resto === 10 || resto === 11) resto = 0;
    if (resto !== parseInt(cpf.substring(9, 10), 10)) return false;
    soma = 0;
    for (let i = 1; i <= 10; i++) soma += parseInt(cpf.substring(i - 1, i), 10) * (12 - i);
    resto = (soma * 10) % 11; if (resto === 10 || resto === 11) resto = 0;
    if (resto !== parseInt(cpf.substring(10, 11), 10)) return false;
    return true;
}

function validarRG(rg) {
    rg = (rg || '').replace(/[^\d]+/g, '');
    if (rg.length < 8 || rg.length > 9) return false;
    if (/^(\d)\1+$/.test(rg)) return false;
    return true;
}

function validarTelefone(tel) {
    tel = (tel || '').replace(/[^\d]+/g, '');
    if (tel.length !== 10 && tel.length !== 11) return false;
    if (/^(\d)\1+$/.test(tel)) return false;
    return true;
}
