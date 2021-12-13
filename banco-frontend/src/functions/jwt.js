const ID_TOKEN_KEY = "id_token";
const EXPIRES_IN_KEY = "expiresIn";

export const getToken = () => {
  return window.localStorage.getItem(ID_TOKEN_KEY);
};

export const saveToken = (token) => {
  window.localStorage.setItem(ID_TOKEN_KEY, token);
};

export const destroyToken = () => {
  window.localStorage.removeItem(ID_TOKEN_KEY);
};

export const getDateExpires = () => {
  return window.localStorage.getItem(EXPIRES_IN_KEY);
};

export const destroyDateExpires = () => {
  window.localStorage.removeItem(EXPIRES_IN_KEY);
};

export const saveDateExpires = (expiresIn) => {
  window.localStorage.setItem(EXPIRES_IN_KEY, expiresIn);
};

export default {
  getToken,
  saveToken,
  destroyToken,
  getDateExpires,
  destroyDateExpires,
  saveDateExpires,
};
