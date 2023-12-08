import {defineStore} from "pinia";
import {ref} from "vue";

export const useNodeModalStore = defineStore("nodeModal", () => {
  const isShowingNodeModal = ref(false);
  const nodeIdToShow = ref(0);

  const openNodeModal = (nodeId) => {
    isShowingNodeModal.value = true;
    nodeIdToShow.value = nodeId;
  };

  const closeNodeModal = () => {
    isShowingNodeModal.value = false;
  };

  return {isShowingNodeModal, nodeIdToShow,  openNodeModal, closeNodeModal};
});
