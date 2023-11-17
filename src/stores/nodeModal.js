import {defineStore} from "pinia";
import {ref} from "vue";

export const useNodeModalStore = defineStore("nodeModal", () => {
  const isShowingNodeModal = ref(false);

  const openNodeModal = () => {
    isShowingNodeModal.value = true;
    console.log('a');
  };


  const closeNodeModal = () => {
    isShowingNodeModal.value = false;
  };

  return {isShowingNodeModal, openNodeModal, closeNodeModal};
});
