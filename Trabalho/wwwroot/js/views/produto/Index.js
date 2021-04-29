let indexProduto = {

    init: () => {
        //aqui vai tudo o que é necessário para a página funcionar no início.

        let selCategoria = document.getElementById("selCategoria")
        selCategoria.innerHTML = "<option>carregando...</option>";
        indexProduto.obterCategorias();

    },

    enviar: () => {

        let dados = {
            nome: document.getElementById("txtNome").value,
            categoria: document.getElementById("selCategoria").value
        }
        HTTPClient.post("/Produto/Gravar", dados)
            .then(result => {
                
                return result.json();
            })
            .then(dados => {

                document.getElementById("gravou").innerHTML = dados.msg;
            })
            .catch(() => {
                console.log("Falha ao Gravar");
            });

    },

    obterCategorias: () => {

        HTTPClient.get("/Produto/ObterCategorias")
            .then(result => {
                return result.json();
            })
            .then(dados => {
                indexProduto.preencherCategorias(dados);
            })
            .catch(() => {
                alert("Não foi possível obter as categorias.");
            })

    },

    preencherCategorias: (dados) => {
        
        let selCategoria = document.getElementById("selCategoria")

        //abordagem 1
        let opts = "<option></option>";

        for (let i = 0; i < dados.length; i++) {

            opts += `<option value="${dados[i].id}">${dados[i].nome}</option>`;
        }

        selCategoria.innerHTML = opts;

        //abordagem 2
        //for (let i = 0; i < dados.length; i++) {

        //    let opt = document.createElement("option");
        //    opt.value = dados[i].id;
        //    opt.innerHTML = dados[i].nome;
        //    selCategoria.appendChild(opt);
        //}


    }
}


document.addEventListener("DOMContentLoaded", () => {

    indexProduto.init();

});

