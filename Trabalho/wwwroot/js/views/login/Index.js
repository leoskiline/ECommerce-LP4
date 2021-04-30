//function logar() {
//    alert("logar 2");
//}


//let logar = () => {
//    alert("logar 2");
//}


let indexLogin = {

    //logar: function () {
    //    alert("logar");
    //}, 

    //arrow function

    logar: () => {

        let usuario = document.getElementById("usuario").value;
        let senhaValor = document.getElementById("senha").value;

        let dados = {
            usuario: usuario, 
            senha: senhaValor
        }

        //Serialização do objeto
        let json = JSON.stringify(dados);

        //Quem isso recebe ?
        /*
        let config = {
            method: 'POST',
            body: json,
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json; charset=utf-8"
            }
        }*/
        //fetch("/Login/Logar", config)

        HTTPClient.post("/Login/Logar", dados)
            .then(function (retornoServidor) {

                return retornoServidor.json();
            })
            .then((dados) => {

                if (!dados.sucesso)
                    document.getElementById("divMsg").innerHTML = "<div class=\"alert alert-danger alert-dismissible fade in\">"+
                        "<a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">×</a>"+
                        "<strong>Erro!</strong> "+dados.msg+
                        "</div>"
                else location.href = "/Home/Index";

            })
            .catch(() => {

                document.getElementById("divMsg").innerHTML = "Deu erro";
            });

    },

    obter: () => {

        let id = 50;

        let config = {
            method: 'GET',
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json; charset=utf-8"
            }
        }

        fetch("/Login/Obter?id=" + id, config)
            .then(function (retornoServidor) {

                return retornoServidor.json();
            })
            .then((dados) => {

                alert(dados.id);
            })
            .catch(() => {

                document.getElementById("divMsg").innerHTML = "Deu erro";
            });

    },

    consultar: () => {

        let nome = encodeURIComponent("andré$#&menegassi");
        //let nomeOriginal = decodeURIComponente(nome);

        let config = {
            method: 'GET',
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json; charset=utf-8"
            }
        }

        fetch("/Login/Consultar?nome=" + nome, config)
            .then(function (retornoServidor) {

                return retornoServidor.json();
            })
            .then((dados) => {

                alert(dados.id);
            })
            .catch(() => {

                document.getElementById("divMsg").innerHTML = "Deu erro";
            });

    },

    alterar: () => {

        let id = 1;
        let usuario = document.getElementById("usuario").value;
        let senhaValor = document.getElementById("senha").value;

        let dados = {
            usuario: usuario, 
            senha: senhaValor
        }

        //Serialização do objeto
        let json = JSON.stringify(dados);

        //Quem isso recebe ?

        let config = {
            method: 'PUT',
            body: json,
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json; charset=utf-8"
            }
        }

        fetch("/Login/Alterar?id=" + id, config)
            .then(function (retornoServidor) {

                return retornoServidor.json();
            })
            .then((dados) => {

                alert(dados.id + " " + dados.usuario.email);

            })
            .catch(() => {

                document.getElementById("divMsg").innerHTML = "Deu erro";
            });

    },


    excluir: function () {

        let id = 1;

        let config = {
            method: 'DELETE',
            headers: {
                'Accept': "application/json",
                "Content-Type": "application/json; charset=utf-8"
            }
        }

        fetch("/Login/Excluir?id=" + id, config)
            .then(function (retornoServidor) {

                return retornoServidor.json();
            })
            .then((dados) => {

                alert(dados.id);

            })
            .catch(() => {

                document.getElementById("divMsg").innerHTML = "Deu erro";
            });
    }
}