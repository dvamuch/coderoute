<script setup>
import CRHelpModalSlot from "@/components/UI/CRHelpModalSlot.vue";
import CRLoginModal from "@/components/UI/CRLoginModalSlot.vue";
import CRModal from "@/components/UI/CRModal.vue";
import CRNodeModal from "@/components/UI/CRNodeModalSlot.vue";
import {useAuthorizationStore} from "@/stores/authorization";
import {useHelpModalStore} from "@/stores/helpModal";
import {useNodeModalStore} from "@/stores/nodeModal";
import {computed} from "vue";

const authorizationStore = useAuthorizationStore();
const nodeModalStore = useNodeModalStore();
const helpModalStore = useHelpModalStore();

const isShowingLoginModal = computed(() => authorizationStore.isShowingLoginModal);
const isShowingNodeModal = computed(() => nodeModalStore.isShowingNodeModal);
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
      <CRNodeModal></CRNodeModal>
    </CRModal>
  </transition>
  <transition name="modal">
    <CRModal v-if="isShowingHelpModal" :close-action="helpModalStore.closeHelpModal">
      <CRHelpModalSlot></CRHelpModalSlot>
    </CRModal>
  </transition>

</template>
