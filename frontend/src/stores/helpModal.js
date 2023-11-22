import {defineStore} from "pinia";
import {ref} from "vue";

export const useHelpModalStore = defineStore("helpModal", () => {
  const isShowingHelpModal = ref(false);

  const openHelpModal = () => {
    isShowingHelpModal.value = true;
    console.log("a");
  };


  const closeHelpModal = () => {
    isShowingHelpModal.value = false;
  };

  return {isShowingHelpModal, openHelpModal, closeHelpModal};
});
