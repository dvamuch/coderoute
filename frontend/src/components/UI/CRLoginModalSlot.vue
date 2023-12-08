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

const authenticateUser = async () => {
  await authorizationStore.authenticateUser(formData.value.login, formData.value.password);
  authorizationModalStore.closeLoginAndRegistrationModal();
};

// const isValid = ref({password: true, login: true});
const isValid = computed(() => {
  return validator.isValid.value || {password: true, login: true};
});
const notifications = computed(() => validator.notifications.value);

const validate = () => {
  const rules = [
    {
      fieldName: "password",
      rule: (v) => v.length > 6,
      notification: "Пароль слишком короткий",
    },
    {
      fieldName: "login",
      rule: (v) => v.length > 3,
      notification: "Логин слишком короткий",

    },
  ];

  validator.validate(formData, rules);
};
</script>

<template>

  <div class="flexibleY gapMedium">
    <h6 class="fn-subcap al-center" style="font-family: 'NT Somic Bold', Arial, Helvetica, sans-serif;"><b>Войти в
      аккаунт</b></h6>

    <form class="flexibleY gapSmall" @submit="authenticateUser">

      {{ isValid }}

      <div class="flexible gapSmaller">
        <!--            <div class="noShrink">-->
        <!--              <div class="uploadAvatar">-->
        <!--                <img class="img avatar" alt="" src="@/assets/avatar.png"/>-->
        <!--                <div class="cameraWrap">-->
        <!--                  <div class="crIcon sMedium" style="&#45;&#45;crMsk: url('/icons/camera_alt.svg');"></div>-->
        <!--                </div>-->
        <!--              </div>-->
        <!--            </div>-->
        <div class="flexibleY gapSmaller grow">
          <CRTextInput placeholder="Email или логин" v-model:text="formData.login"
                       @update:text="validate()" :is-valid="isValid.login"></CRTextInput>
          <CRPasswordInput v-model:password="formData.password"
                           @update:password="validate()"></CRPasswordInput>
        </div>
      </div>

      <div class="flexibleY gapSmaller">
        <div class="al-center fn-alert" v-if="notifications" v-for="notification in notifications">{{
            notification
          }}
        </div>
        <div class="flexible gapSmallest">
          <button class="crFormItem button secondary filled hLarge radRound grow">Забыл(а) пароль?
          </button>
          <button type="submit" class="crFormItem button primary filled hLarge radRound grow" @click="authenticateUser">
            Войти в
            CodeRoute
          </button>
        </div>
      </div>

      <div class="al-center">Еще нет аккаунта? <a class="link" title="" @click="openRegistrationModal">Зарегистрироваться</a>
      </div>
    </form>
  </div>
</template>
