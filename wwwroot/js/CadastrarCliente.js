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