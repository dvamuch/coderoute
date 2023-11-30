<script setup>

import CRPasswordInput from "@/components/UI/CRPasswordInput.vue";
import CRTextInput from "@/components/UI/CRTextInput.vue";
import {useAuthorizationModalStore} from "@/stores/authorizationModal";

const authorizationStore = useAuthorizationModalStore();
const openLoginModal = authorizationStore.openLoginModal;
</script>

<template>
  <div class="flexibleY gapMedium">
    <h6 class="fn-subcap al-center"><b>Создать аккаунт</b></h6>

    <form class="flexibleY gapSmall">


      <div class="flexible gapSmaller">
        <div class="flexibleY gapSmaller grow">

          <CRTextInput placeholder="Имя пользователя"></CRTextInput>
          <CRTextInput placeholder="Email"></CRTextInput>

          <CRPasswordInput></CRPasswordInput>
          <CRPasswordInput placeholder="Пароль повторно"></CRPasswordInput>
        </div>
      </div>

      <div class="flexibleY gapSmaller">
        <div class="al-center fn-alert">Неверный email или пароль</div>
        <div class="flexible gapSmallest">
          <button class="crFormItem button primary filled hLarge radRound grow">Зарегистрироваться</button>
        </div>
      </div>

      <div class="al-center">Уже есть аккаунт? <a class="link" title="" @click="openLoginModal">Войти в CodeRoute</a>
      </div>
    </form>
  </div>
</template>
