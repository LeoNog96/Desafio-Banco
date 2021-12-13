import Vue from "vue";
import Vuex from "vuex";
import Jwt from "./jwt";

Vue.use(Vuex);
// action types
export const VERIFY_AUTH = "verifyAuth";
export const LOGIN = "login";
export const LOGOUT = "logout";
export const REGISTER = "register";
export const UPDATE_USER = "updateUser";

// mutation types
export const PURGE_AUTH = "logOut";
export const SET_AUTH = "setUser";
export const SET_ERROR = "setError";

export default new Vuex.Store({
  state: {
    errors: null,
    user: {},
    isAuthenticated: !!Jwt.getToken()
  },
  mutations: {
    [SET_ERROR](state, error) {
      state.errors = error;
    },
    [SET_AUTH](state, data) {
      state.token = data;

      Jwt.saveToken(state.token);
      Jwt.saveDateExpires(state.DdtaExpiracao);
      window.localStorage.setItem("idPessoa", JSON.stringify(data.idPessoa));
    },
    [PURGE_AUTH](state) {
      state.isAuthenticated = false;
      state.user = {};
      state.errors = {};
      Jwt.destroyToken();
      Jwt.destroyDateExpires();
    }
  },
  actions: {
    [LOGIN](context, data) {
      context.commit(SET_AUTH, data);
    },
    [LOGOUT](context) {
      context.commit(PURGE_AUTH);
    },
  },
  modules: {},
});
