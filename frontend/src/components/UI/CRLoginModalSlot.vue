<script setup>

import CRPasswordInput from "@/components/UI/CRPasswordInput.vue";
import CRTextInput from "@/components/UI/CRTextInput.vue";
import {useAuthorizationStore} from "@/stores/authorization";
import {useAuthorizationModalStore} from "@/stores/authorizationModal";
import useValidator from "@/use/validator";
import {computed, ref} from "vue";

const validator = useValidator();
const authorizationModalStore = useAuthorizationModalStore();
const authorizationStore = useAuthorizationStore();
const openRegistrationModal = authorizationModalStore.openRegistrationModal;

const formData = ref({
  password: "",
  login: "",
});

const validate = () => {
  const rules = [
    {
      fieldNames: ["login", "password"],
      rule: (v) => v.length !== 0,
      notification: "emptyInputs",
    },
  ];

  validator.validate(formData, rules);
};


const isValid = computed(() => {
  return validator.isValid.value || {password: true, login: true};
});
const notifications = computed(() => validator.notifications.value);
const isOk = computed(() => validator.isOk.value);
const isAuthorized = computed(() => authorizationStore.isAuthorized.value);

const authenticateUser = async () => {
  validate();
  // console.log(!isOk.value);
  if (!isOk.value) {
    return;
  }
  await authorizationStore.authenticateUser(formData.value.login, formData.value.password);

  if (!isAuthorized.value) {
    notifications.value["wrongCredentials"] = true;
    return;
  }
  authorizationModalStore.closeLoginAndRegistrationModal();
};


</script>

<template>

  <div class="flexibleY gapMedium">
    <h6 class="fn-subcap al-center" style="font-family: 'NT Somic Bold', Arial, Helvetica, sans-serif;"><b>Войти в
      аккаунт</b></h6>

    <form class="flexibleY gapSmall" @submit="authenticateUser">

      <!--      {{ isValid }}-->
      <!--      {{ notifications }}-->

      <div class="flexible gapSmaller">
        <div class="flexibleY gapSmaller grow">
          <CRTextInput placeholder="Email или логин" v-model:text="formData.login"
                       @update:text="validate" :is-valid="isValid.login"></CRTextInput>
          <CRPasswordInput v-model:password="formData.password"
                           @update:password="validate" :is-valid="isValid.password"></CRPasswordInput>
        </div>
      </div>

      <div class="flexibleY gapSmaller">
        <div class="al-center fn-alert" v-if="notifications?.emptyInputs">Есть пустые поля!</div>
        <div class="al-center fn-alert" v-if="notifications?.wrongCredentials">Неверный email или пароль</div>

        <div class="flexible gapSmallest">
          <button class="crFormItem button secondary filled hLarge radRound grow">Забыл(а) пароль?
          </button>
          <button type="submit" class="crFormItem button primary filled hLarge radRound grow" @click="authenticateUser">
            Войти в CodeRoute
          </button>
        </div>
      </div>

      <div class="al-center">Еще нет аккаунта? <a class="link" title="" @click="openRegistrationModal">Зарегистрироваться</a>
      </div>
    </form>
  </div>
</template>
