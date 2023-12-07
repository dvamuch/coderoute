<script setup>

import CRLogo from "@/components/UI/CRLogo.vue";
import {useAuthorizationStore} from "@/stores/authorization";

import {useAuthorizationModalStore} from "@/stores/authorizationModal";
import {computed} from "vue";

const authorizationModalStore = useAuthorizationModalStore();
const authorizationStore = useAuthorizationStore();
const openLoginModal = authorizationModalStore.openLoginModal;
const openRegistrationModal = authorizationModalStore.openRegistrationModal;

const isAuthorized = computed(() => authorizationStore.isAuthorized);
const userLogin = computed(() => authorizationStore.userLogin);
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


    <ul class="flexible" v-if="!isAuthorized">
      <li class="crFormItem button hMedium transparent" @click="openLoginModal">Войти</li>
      <li class="crFormItem button primary radRound filled hMedium" @click="openRegistrationModal">Регистрация</li>
    </ul>

    <ul class="flexible" v-if="isAuthorized">
      <li class="crFormItem button hMedium transparent">
        <a class="flexible gapXSmallest">
          <div>{{ userLogin}}</div>
          <div class="crMiniAvatar sSmall">
            <img class="img avatar" alt="" src="@/assets/avatar.png"/>
          </div>
        </a>
      </li>
    </ul>
  </nav>
</template>
