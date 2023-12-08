<script setup>
import CRHelpModalSlot from "@/components/UI/CRHelpModalSlot.vue";
import CRLoginModalSlot from "@/components/UI/CRLoginModalSlot.vue";
import CRModal from "@/components/UI/CRModal.vue";
import CRNodeModalSlot from "@/components/UI/CRNodeModalSlot.vue";
import CRRegistrationModalSlot from "@/components/UI/CRRegistrationModalSlot.vue";
import {useAuthorizationModalStore} from "@/stores/authorizationModal";
import {useHelpModalStore} from "@/stores/helpModal";
import {useNodeModalStore} from "@/stores/nodeModal";
import {computed} from "vue";

const authorizationModalStore = useAuthorizationModalStore();
const nodeModalStore = useNodeModalStore();
const helpModalStore = useHelpModalStore();

const isShowingLoginModal = computed(() => authorizationModalStore.isShowingLoginModal);
const isShowingRegistrationModal = computed(() => authorizationModalStore.isShowingRegistrationModal);
const isShowingNodeModal = computed(() => nodeModalStore.isShowingNodeModal);
const nodeIdToShow = computed(() => nodeModalStore.nodeIdToShow);
const isShowingHelpModal = computed(() => helpModalStore.isShowingHelpModal);

</script>

<template>
  <transition name="modal">
    <CRModal v-if="isShowingLoginModal" :close-action="authorizationModalStore.closeLoginAndRegistrationModal">
      <CRLoginModalSlot></CRLoginModalSlot>
    </CRModal>
  </transition>
  <transition name="modal">
    <CRModal v-if="isShowingRegistrationModal" :close-action="authorizationModalStore.closeLoginAndRegistrationModal">
      <CRRegistrationModalSlot></CRRegistrationModalSlot>
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
