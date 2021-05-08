
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
            debugger
            linhas += `<div class="card col-md-4 text-center" style="width:20%;margin-top:20px;margin-bottom:20px">
                      <img class="card-img-top" src="/Produto/ObterImagem/${item.id}" width="150px" height="150px" alt="Card image">
                      <div class="card-body">
                        <h4 class="card-title">${item.nome}</h4>
                        <p class="card-text">Categoria: ${item.categoria.nome}.</p>
                        <a href="#" class="btn btn-primary">Comprar</a>
                      </div>
                    </div>`
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