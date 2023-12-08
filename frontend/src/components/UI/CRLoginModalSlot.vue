<script setup>

import CRPasswordInput from "@/components/UI/CRPasswordInput.vue";
import CRTextInput from "@/components/UI/CRTextInput.vue";
import {useAuthorizationStore} from "@/stores/authorization";
import {useAuthorizationModalStore} from "@/stores/authorizationModal";
import {ref} from "vue";

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

const isValid = ref({password: true, login: true});

const validate = (fieldName) => {
  const rules = {
    password: (v) => {
      return v.length > 6;
    },
    login: (v) => {
      return v.length > 3;
    },
  };

  isValid.value[fieldName] = rules[fieldName](formData.value[fieldName]);
};
</script>

<template>

  <div class="flexibleY gapMedium">
    <h6 class="fn-subcap al-center"><b>Войти в аккаунт</b></h6>

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
                       @update:text="validate('login')"></CRTextInput>
          <CRPasswordInput v-model:password="formData.password"
                           @update:password="validate('password', )"></CRPasswordInput>
        </div>
      </div>

      <div class="flexibleY gapSmaller">
        <!--        <div class="al-center fn-alert">Неверный email или пароль</div>-->
        <div class="flexible gapSmallest">
          <button class="crFormItem button secondary filled hLarge radRound grow">Забыл(а) пароль?
          </button>
          <button type="submit" class="crFormItem button primary filled hLarge radRound grow" @click="authenticateUser">Войти в
            CodeRoute
          </button>
        </div>
      </div>

      <div class="al-center">Еще нет аккаунта? <a class="link" title="" @click="openRegistrationModal">Зарегистрироваться</a>
      </div>
    </form>
  </div>
</template>
