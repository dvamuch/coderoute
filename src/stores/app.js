import {defineStore} from "pinia";
import {ref} from "vue";


export const useAppStore = defineStore("app", () => {
  const showModal = ref(false);

  const setModal = (newValue) => {
    showModal.value = newValue;
  }

  return {showModal, setModal};
});
