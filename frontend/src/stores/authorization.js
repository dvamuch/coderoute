import useMyLocalStorage from "@/use/myLocalStorage";
import {defineStore} from "pinia";
import {computed, ref} from "vue";
import VueJwtDecode from "vue-jwt-decode";


export const useAuthorizationStore = defineStore("authorization", () => {
    const userObject = ref({
      jwtToken: null,
      userLogin: null,
      userId: null,
    });

    const myLocalStorage = useMyLocalStorage();

    const isAuthorized = computed(() => !!userObject.value?.userLogin);
    const jwtToken = computed(() => userObject.value?.jwtToken);
    const userLogin = computed(() => userObject.value?.userLogin);


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

    const checkAuth = () => {
      if (myLocalStorage.has("user")) {
        userObject.value = myLocalStorage.get("user");
      }
    };

    const deauthenticateUser = () => {
      userObject.value = {
        jwtToken: null,
        userLogin: null,
        userId: null,
      };
      myLocalStorage.remove("user");
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
        const json = await result.json();
        const user = VueJwtDecode.decode(json.token);
        console.log(json, user);

        userObject.value = {
          jwtToken: json.token,
          userLogin: user.sub,
          userId: user.nameid,
        };

        myLocalStorage.set("user", userObject.value);

        console.log("Вы авторизовались!");
        console.log("userObject", userObject.value);
        console.log("jwtToken", jwtToken.value);
      } else {
        console.log("Ошибка авторизации");
      }
    };

    return {
      isAuthorized,
      registerUser,
      authenticateUser,
      userObject,
      jwtToken,
      userLogin,
      checkAuth,
      deauthenticateUser,
    };
  },
);
