<script setup>
import CRLoginModal from "@/components/UI/CRLoginModal.vue";
import CRModal from "@/components/UI/CRModal.vue";
import CRNodeModal from "@/components/UI/CRNodeModal.vue";
import {useAuthorizationStore} from "@/stores/authorization";
import {useNodeModalStore} from "@/stores/nodeModal";
import {computed} from "vue";

const authorizationStore = useAuthorizationStore();
const nodeModalStore = useNodeModalStore();

const isShowingLoginModal = computed(() => authorizationStore.isShowingLoginModal);
const isShowingNodeModal = computed(() => nodeModalStore.isShowingNodeModal);

</script>

<template>

  <CRModal v-if="isShowingLoginModal" :close-action="authorizationStore.closeLoginAndRegistrationModal">
    <CRLoginModal></CRLoginModal>
  </CRModal>
  <CRModal v-if="isShowingNodeModal" :close-action="nodeModalStore.closeNodeModal">
    <CRNodeModal></CRNodeModal>
  </CRModal>

</template>
