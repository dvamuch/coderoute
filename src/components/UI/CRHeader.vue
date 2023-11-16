<script setup>

import CRLogo from "@/components/UI/CRLogo.vue";

import {useAuthorizationStore} from "@/stores/authorization";

const authorizationStore = useAuthorizationStore();
const openLoginModal = authorizationStore.openLoginModal;
</script>

<template>

  <h1 class="hide">CodeRoute</h1>

  <nav class="crMainNav gapMedium">
    <div class="flexible gapMedium">
      <router-link class="noShrink" to="/">
        <CRLogo></CRLogo>
      </router-link>
      <router-link to="/roadmaps" class="crFormItem button hMedium transparent nopad">Дорожные карты</router-link>
    </div>


    <ul class="flexible">
      <li class="crFormItem button hMedium transparent" @click="openLoginModal">Войти</li>
      <li class="crFormItem button primary radRound filled hMedium">Регистрация</li>
    </ul>

    <!--    <ul class="flexible">-->
    <!--      <li class="crFormItem button hMedium transparent">-->
    <!--        <a class="flexible gapXSmallest">-->
    <!--          <div>hiikari</div>-->
    <!--          <div class="crMiniAvatar sSmall">-->
    <!--            <img class="img avatar" alt="" src="@/assets/avatar.png"/>-->
    <!--          </div>-->
    <!--        </a>-->
    <!--      </li>-->
    <!--    </ul>-->
  </nav>
</template>
