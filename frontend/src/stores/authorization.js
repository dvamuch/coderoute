import {defineStore} from "pinia";
import {ref} from "vue";

export const useAuthorizationStore = defineStore("authorization", () => {
  const isShowingLoginModal = ref(false);
  const isShowingRegistrationModal = ref(false);

  const openLoginModal = () => {
    isShowingLoginModal.value = true;
    isShowingRegistrationModal.value = false;
  };

  const openRegistrationModal = () => {
    isShowingRegistrationModal.value = true;
    isShowingLoginModal.value = false;
  };

  const closeLoginAndRegistrationModal = () => {
    isShowingRegistrationModal.value = false;
    isShowingLoginModal.value = false;
  };

  return {
    isShowingLoginModal,
    isShowingRegistrationModal,
    openLoginModal,
    openRegistrationModal,
    closeLoginAndRegistrationModal,
  };
});
