<script setup>

import CRPasswordInput from "@/components/UI/CRPasswordInput.vue";
import CRTextInput from "@/components/UI/CRTextInput.vue";
import {useAuthorizationStore} from "@/stores/authorization";
import {useAuthorizationModalStore} from "@/stores/authorizationModal";
import {ref} from "vue";

const authorizationModalStore = useAuthorizationModalStore();
const authorizationStore = useAuthorizationStore();

const openLoginModal = authorizationModalStore.openLoginModal;


const email = ref("");
const login = ref("");
const password = ref("");
const passwordRepeat = ref("");

const registerUser = async () => {
  await authorizationStore.registerUser(email.value, login.value, password.value);
  await authorizationStore.authenticateUser(login.value, password.value);
  authorizationModalStore.closeLoginAndRegistrationModal();
};
</script>

<template>
  <div class="flexibleY gapMedium">
    <h6 class="fn-subcap al-center"><b>Создать аккаунт</b></h6>

    <form class="flexibleY gapSmall">


      <div class="flexible gapSmaller">
        <div class="flexibleY gapSmaller grow">

          <CRTextInput placeholder="Имя пользователя" v-model:text="login"></CRTextInput>
          <CRTextInput placeholder="Email" v-model:text="email"></CRTextInput>

          <CRPasswordInput v-model:password="password"></CRPasswordInput>
          <CRPasswordInput v-model:password="passwordRepeat" placeholder="Пароль повторно"></CRPasswordInput>
        </div>
      </div>

      <div class="flexibleY gapSmaller">
        <div class="al-center fn-alert">Неверный email или пароль</div>
        <div class="flexible gapSmallest">
          <button type="submit" class="crFormItem button primary filled hLarge radRound grow" @click="registerUser">
            Зарегистрироваться
          </button>
        </div>
      </div>

      <div class="al-center">Уже есть аккаунт? <a class="link" title="" @click="openLoginModal">Войти в CodeRoute</a>
      </div>
    </form>
  </div>
</template>
