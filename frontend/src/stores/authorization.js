import {useAuthorizationModalStore} from "@/stores/authorizationModal";
import {defineStore} from "pinia";
import {ref} from "vue";

export const useAuthorizationStore = defineStore("authorization", () => {
    const authorizationModalStore = useAuthorizationModalStore();

    const jwtToken = ref("");
    const isAuthorized = ref(false);

    const registerUser = async (email, login, password) => {
      const result = await fetch(`http://${process.env.VUE_APP_BACKEND_HOST}/User/reg`, {
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

      return result;
    };

    const authenticateUser = async (email, login, password) => {
      const result = await fetch(`http://${process.env.VUE_APP_BACKEND_HOST}/User/auth`, {
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

      if (result.status === 200) {
        jwtToken.value = (await result.json()).token;
        isAuthorized.value = true;

        authorizationModalStore.closeLoginAndRegistrationModal();
        console.log(jwtToken.value);
      } else {
        console.log("Ты еблан");
      }
    };

    return {
      isAuthorized,
      registerUser,
      authenticateUser,
    };
  },
);
