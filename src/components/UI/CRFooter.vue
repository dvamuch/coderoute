<script setup>
import FooterMenuComponent from "@/components/UI/CRFooterMenu.vue";
import CRLoginModal from "@/components/UI/CRLoginModal.vue";
import LogoComponent from "@/components/UI/CRLogo.vue";

import {useAuthorizationStore} from "@/stores/authorization"
import {computed} from "vue";

const authorizationStore = useAuthorizationStore();
const isShowingLoginModal = computed(() => authorizationStore.isShowingLoginModal);

</script>

<template>
  <footer class="crFooter">
    <div class="leftSide flexibleY gapSmallest">
      <router-link class="flexible gapSmallest" to="/">
        <LogoComponent></LogoComponent>
        <span>Code<span class="fn-primary">Route</span></span>
      </router-link>
      <p>© 2023 CodeRoute. Все права защищены </p>
    </div>
    <div class="rightSide flexible">
      <FooterMenuComponent title="О продукте" :menu-items="['Новости', 'Команда']"></FooterMenuComponent>
      <FooterMenuComponent title="Давайте общаться" :menu-items="['Наши контакты', 'GitHub']"></FooterMenuComponent>
    </div>
  </footer>


  <CRLoginModal v-if="isShowingLoginModal"></CRLoginModal>
</template>
