function exibirAlerta(mensagem, tipo) {
    Swal.fire({
        title: mensagem,
        icon: tipo, // 'success', 'error', 'warning', 'info'
        confirmButtonText: 'OK'
    });
}

console.log("CadastrarCliente.js carregado!");