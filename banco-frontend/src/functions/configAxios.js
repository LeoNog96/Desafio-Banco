import Vue from "vue";
import Axios from "axios";
import Jwt from "./jwt";
import Swal from "sweetalert2";

export class ConfigAxios {
  constructor() {
    Axios.defaults.baseURL = process.env.VUE_APP_ROOT_API_SHARP + "/api/";
    Axios.defaults.headers.common["Access-Control-Allow-Origin"] = "*";
    Axios.defaults.headers.common["Access-Control-Expose-Headers"] =
      "Content-Length";
    Axios.defaults.headers.common["Access-Control-Allow-Credentials"] = "true";
    Axios.defaults.headers.common["Content-Type"] = "application/json";
    Axios.defaults.headers.common["charset"] = "utf-8";
    Axios.defaults.crossDomain = true;

    Vue.prototype.$http = Axios;

    Vue.axios.interceptors.response.use(
      (response) => response,
      (error) => {
        if (error.response.status == 401)
          Swal.fire({
            title: "Tempo de Acesso Expirado",
            text: "Você será redirecionado para a tela de Login em 5 segundos.",
            timer: 5000,
            allowOutsideClick: false,
            onOpen: function () {
              Swal.showLoading();
            },
          }).then(function (result) {
            if (result.dismiss === "timer") {
              Jwt.destroyToken();
              Jwt.destroyDateExpires();
            }
          });
        else {
          Swal.fire({
            position: "center",
            icon: "error",
            title: error.response.data.titulo,
            text: error.response.data.notificacoes
              .map((x) => x.mensagem)
              .join(", "),
            showConfirmButton: false
          });
        }
        return Promise.reject(error);
      }
    );

    if (window.isDebug) console.log("Caminho da API:", Axios.defaults.baseURL);
  }
}
