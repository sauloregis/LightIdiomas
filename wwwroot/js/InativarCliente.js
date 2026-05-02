function alternarStatus(id) {
    fetch(`/InativarCliente/AlternarStatus/${id}`, {
        method: 'POST'
    })
        .then(response => {
            if (response.redirected) {
                window.location.href = response.url;
            } else {
                window.location.reload();
            }
        });
}