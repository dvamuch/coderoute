export default function useLocalStorage() {
  const has = (key) => {
    return !!localStorage[key];
  };

  const get = (key) => {
    return JSON.parse(localStorage[key]);
  };

  const set = (key, value) => {
    localStorage[key] = JSON.stringify(value);
  };

  return {has, get, set};
}
