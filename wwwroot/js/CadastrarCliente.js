function exibirAlerta(mensagem, tipo) {
    Swal.fire({
        title: mensagem,
        icon: tipo, // 'success', 'error', 'warning', 'info'
        confirmButtonText: 'OK'
    });
}

document.getElementById("estadoSelect").addEventListener("change", function () {
    var estadoId = this.value;
    var cidadeSelect = document.getElementById("cidadeSelect");

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

function validarCPF(cpf) {

    cpf = cpf.replace(/[^\d]+/g, '');

    if (cpf.length !== 11 || /^(\d)\1+$/.test(cpf))
        return false;

    let soma = 0;
    let resto;

    for (let i = 1; i <= 9; i++)
        soma += parseInt(cpf.substring(i - 1, i)) * (11 - i);

    resto = (soma * 10) % 11;

    if (resto === 10 || resto === 11)
        resto = 0;

    if (resto !== parseInt(cpf.substring(9, 10)))
        return false;

    soma = 0;

    for (let i = 1; i <= 10; i++)
        soma += parseInt(cpf.substring(i - 1, i)) * (12 - i);

    resto = (soma * 10) % 11;

    if (resto === 10 || resto === 11)
        resto = 0;

    if (resto !== parseInt(cpf.substring(10, 11)))
        return false;

    return true;
}

document.querySelector("form").addEventListener("submit", function (e) {

    let cpf = document.querySelector("#CPF").value;

    if (!validarCPF(cpf)) {

        alert("CPF inválido!");
        e.preventDefault();
    }
});
