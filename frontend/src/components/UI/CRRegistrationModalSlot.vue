<script setup>

import CRPasswordInput from "@/components/UI/CRPasswordInput.vue";
import CRTextInput from "@/components/UI/CRTextInput.vue";
import {useAuthorizationStore} from "@/stores/authorization";
import {useAuthorizationModalStore} from "@/stores/authorizationModal";
import useValidator from "@/use/validator";
import {computed, ref} from "vue";

const authorizationModalStore = useAuthorizationModalStore();
const authorizationStore = useAuthorizationStore();

const openLoginModal = authorizationModalStore.openLoginModal;
const validator = useValidator();


const formData = ref({
  email: "",
  login: "",
  password: "",
  passwordRepeat: "",
});
const isValid = computed(() => {
  return validator.isValid.value || {password: true, login: true, email: true, passwordRepeat: true};
});
const notifications = computed(() => validator.notifications.value);
const isOk = computed(() => validator.isOk.value);
const isAuthorized = computed(() => {
  return authorizationStore.isAuthorized
});

const validate = () => {
  const rules = [
    {
      fieldNames: ["login", "email", "password", "passwordRepeat"],
      rule: (v) => v.length !== 0,
      notification: "emptyInputs",
    },
    {
      fieldNames: ["login"],
      rule: (v) => v.length > 4,
      notification: "smallLogin",
    },
    {
      fieldNames: ["login"],
      rule: (v) => v.length < 20,
      notification: "longLogin",
    },
    {
      fieldNames: ["login"],
      rule: (v) => v.match(/^(?=.*[A-Za-z0-9]$)[A-Za-z][A-Za-z\d.-]{0,19}$/),
      notification: "wrongSymbolsInLogin",
    },
    {
      fieldNames: ["email"],
      rule: (v) => {
        const validateEmailRegex = /^\S+@\S+\.\S+$/;
        return validateEmailRegex.test(v);
      },
      notification: "emailInvalid",
    },
    {
      fieldNames: ["password"],
      rule: (v) => v.length > 8,
      notification: "smallPassword",
    },
    {
      fieldNames: ["password"],
      rule: (v) => v.length < 30,
      notification: "longPassword",
    },
    {
      fieldNames: ["password"],
      rule: (v) => v === formData.value.passwordRepeat,
      notification: "passwordsNotEqual",
    },
    {
      fieldNames: ["passwordRepeat"],
      rule: (v) => v === formData.value.password,
      notification: "passwordsNotEqual",
    },
  ];

  validator.validate(formData, rules);
};

const registerUser = async () => {
  validate();
  if (!isOk.value) {
    return;
  }
  await authorizationStore.registerUser(formData.value.email, formData.value.login, formData.value.password);
  await authorizationStore.authenticateUser(formData.value.login, formData.value.password);
  authorizationModalStore.closeLoginAndRegistrationModal();
  if (!isAuthorized.value) {
    notifications.value["wrongCredentials"] = true;
    return;
  }
  authorizationModalStore.closeLoginAndRegistrationModal();
};
</script>

<template>
  <div class="flexibleY gapMedium">
    <h6 class="fn-subcap al-center" style="font-family: 'NT Somic Bold', Arial, Helvetica, sans-serif;"><b>Создать
      аккаунт</b></h6>

    <form class="flexibleY gapSmall">


      <div class="flexible gapSmaller">
        <div class="flexibleY gapSmaller grow">


          <CRTextInput placeholder="Имя пользователя" v-model:text="formData.login" :is-valid="isValid.login"
                       @update:text="validate"></CRTextInput>
          <CRTextInput placeholder="Email" v-model:text="formData.email" :is-valid="isValid.email"
                       @update:text="validate"></CRTextInput>

          <CRPasswordInput v-model:password="formData.password" :is-valid="isValid.password"
                           @update:password="validate"></CRPasswordInput>
          <CRPasswordInput v-model:password="formData.passwordRepeat" placeholder="Пароль повторно"
                           :is-valid="isValid.passwordRepeat" @update:password="validate"></CRPasswordInput>
        </div>
      </div>

      <div class="flexibleY gapSmaller">
        <div class="al-center fn-alert" v-if="notifications?.wrongCredentials">Неверный email или пароль</div>
        <div class="al-center fn-alert" v-if="notifications?.emptyInputs">Есть пустые поля</div>
        <div class="al-center fn-alert" v-if="notifications?.wrongSymbolsInLogin">Логин содержит недопустимые символы</div>
        <div class="al-center fn-alert" v-if="notifications?.smallLogin">Логин слишком короткий</div>
        <div class="al-center fn-alert" v-if="notifications?.longLogin">Логин слишком длинный</div>
        <div class="al-center fn-alert" v-if="notifications?.smallPassword">Пароль слишком короткий</div>
        <div class="al-center fn-alert" v-if="notifications?.longPassword">Пароль слишком короткий</div>
        <div class="al-center fn-alert" v-if="notifications?.passwordsNotEqual">Пароли не совпадают</div>
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
