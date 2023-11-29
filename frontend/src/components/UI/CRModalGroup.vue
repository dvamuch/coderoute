<script setup>
import CRHelpModalSlot from "@/components/UI/CRHelpModalSlot.vue";
import CRLoginModal from "@/components/UI/CRLoginModalSlot.vue";
import CRModal from "@/components/UI/CRModal.vue";
import CRNodeModalSlot from "@/components/UI/CRNodeModalSlot.vue";
import {useAuthorizationModalStore} from "@/stores/authorizationModal";
import {useHelpModalStore} from "@/stores/helpModal";
import {useNodeModalStore} from "@/stores/nodeModal";
import {computed} from "vue";

const authorizationStore = useAuthorizationModalStore();
const nodeModalStore = useNodeModalStore();
const helpModalStore = useHelpModalStore();

const isShowingLoginModal = computed(() => authorizationStore.isShowingLoginModal);
const isShowingNodeModal = computed(() => nodeModalStore.isShowingNodeModal);
const nodeIdToShow = computed(() => nodeModalStore.nodeIdToShow);
const isShowingHelpModal = computed(() => helpModalStore.isShowingHelpModal);

</script>

<template>
  <transition name="modal">
    <CRModal v-if="isShowingLoginModal" :close-action="authorizationStore.closeLoginAndRegistrationModal">
      <CRLoginModal></CRLoginModal>
    </CRModal>
  </transition>
  <transition name="modal">
    <CRModal v-if="isShowingNodeModal" :close-action="nodeModalStore.closeNodeModal">
      <CRNodeModalSlot :node-id="nodeIdToShow"></CRNodeModalSlot>
    </CRModal>
  </transition>
  <transition name="modal">
    <CRModal v-if="isShowingHelpModal" :close-action="helpModalStore.closeHelpModal">
      <CRHelpModalSlot></CRHelpModalSlot>
    </CRModal>
  </transition>

</template>
