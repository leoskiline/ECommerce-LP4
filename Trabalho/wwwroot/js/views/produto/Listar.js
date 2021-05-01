
listarProduto = {

    init: () => {
        listarProduto.obterProdutos();
    },

    obterProdutos: () => {

        HTTPClient.get("/Produto/ObterTodos")
            .then(result => {
                return result.json();
            })
            .then(dados => {
                listarProduto.preencherProdutos(dados);
            })
            .catch(() => {
                alert("Não foi possível obter os produtos.");
            })

    },

    preencherProdutos: (dados) => {

        document.getElementById("divResultado").classList.remove("d-none");

        let bodyResultado = document.getElementById("bodyResultado");

        let linhas = "";
        dados.forEach(item => {

            linhas += `<tr data-produto-id=${item.id}>
                            <td>${item.nome}</td>
                            <td>${item.categoria.nome}</td>
                       </tr>`
        });

        bodyResultado.innerHTML = linhas;

    },

    excluir: (id, nome) => {

        if (!confirm(`Deseja excluir "${nome}" ?`))
            return;

        //ajax -> id
        HTTPClient.delete("/Produto/Excluir?id=" + id)
            .then(r => {
                return r.json();
            })
            .then(dados => {

                if (dados.sucesso) {
                    listarProduto.removerLinha(id);
                    alert("Removido com Sucesso!!!");
                }
                else
                    alert("Falha ao Remover Produto.");
            })
            .catch(() => {

                alert("Deu erro");
            });

    },

    removerLinha: (id) => {

        let tr = document.querySelector(`tr[data-produto-id='${id}']`);
        document.getElementById("bodyResultado").removeChild(tr);
    }

}

document.addEventListener("DOMContentLoaded", () => {

    listarProduto.init();

});