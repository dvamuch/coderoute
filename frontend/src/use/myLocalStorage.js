export default function useMyLocalStorage() {
  const has = (key) => {
    return !!localStorage.getItem(key);
  };

  const get = (key) => {
    return JSON.parse(localStorage.getItem(key));
  };

  const set = (key, value) => {
    localStorage.setItem(key, JSON.stringify(value));
  };

  const remove = (key) => {
    localStorage.removeItem(key);
  };

  return {has, get, set, remove};
}
