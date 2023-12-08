import {defineStore} from "pinia";
import {ref} from "vue";

export const useNodeModalStore = defineStore("nodeModal", () => {
  const isShowingNodeModal = ref(false);
  const nodeIdToShow = ref(0);
  const parentNodeIdToShow = ref(0);

  const openNodeModal = (nodeId, parentNodeId) => {
    isShowingNodeModal.value = true;
    nodeIdToShow.value = nodeId;
    parentNodeIdToShow.value = parentNodeId;
  };

  const closeNodeModal = () => {
    isShowingNodeModal.value = false;
  };

  return {isShowingNodeModal, nodeIdToShow,  openNodeModal, closeNodeModal, parentNodeIdToShow};
});
