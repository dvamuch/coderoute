import {defineStore} from "pinia";
import {ref} from "vue";
import VueJwtDecode from "vue-jwt-decode";

export const useAuthorizationStore = defineStore("authorization", () => {
    const jwtToken = ref("");
    const isAuthorized = ref(false);
    const userLogin = ref("");

    const registerUser = async (email, login, password) => {
      console.log(email, login, password);

      const result = await fetch(`http://${process.env.VUE_APP_BACKEND_HOST}/api/v1/User/reg`, {
        method: "POST",
        body: JSON.stringify({
          email: email,
          userName: login,
          password: password,
        }),
        headers: {
          "Content-Type": "application/json",
        },
      });

      console.log(result);
      console.log(await result.text());
    };

    const authenticateUser = async (loginOrEmail, password) => {
      const result = await fetch(`http://${process.env.VUE_APP_BACKEND_HOST}/api/v1/User/auth`, {
        method: "POST",
        body: JSON.stringify({
          login: loginOrEmail,
          password: password,
        }),
        headers: {
          "Content-Type": "application/json",
        },
      });

      if (result.status === 200) {
        jwtToken.value = (await result.json()).token;
        isAuthorized.value = true;
        userLogin.value = VueJwtDecode.decode(jwtToken.value).sub;

        console.log("Вы авторизовались!");
        console.log(jwtToken.value);
      } else {
        console.log("Ты еблан");
      }
    };

    return {
      isAuthorized,
      registerUser,
      authenticateUser,
      userLogin,
      jwtToken
    };
  },
);
