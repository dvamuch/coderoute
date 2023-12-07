<script setup>

import CRPasswordInput from "@/components/UI/CRPasswordInput.vue";
import CRTextInput from "@/components/UI/CRTextInput.vue";
import {useAuthorizationModalStore} from "@/stores/authorizationModal";
import {ref} from "vue";

const authorizationStore = useAuthorizationModalStore();
const openRegistrationModal = authorizationStore.openRegistrationModal;

const password = ref("");
const login = ref("");

const afdsfsa = () => {
  console.log(login.value);
  console.log(password.value);
};
</script>

<template>

  <div class="flexibleY gapMedium">
    <h6 class="fn-subcap al-center"><b>Войти в аккаунт</b></h6>

    <form class="flexibleY gapSmall">


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
          <CRTextInput placeholder="Email или логин" v-model:text="login"></CRTextInput>
          <CRPasswordInput v-model:password="password"></CRPasswordInput>
        </div>
      </div>

      <div class="flexibleY gapSmaller">
        <!--        <div class="al-center fn-alert">Неверный email или пароль</div>-->
        <div class="flexible gapSmallest">
          <button type="submit" class="crFormItem button secondary filled hLarge radRound grow">Забыл(а) пароль?
          </button>
          <button class="crFormItem button primary filled hLarge radRound grow" @click="afdsfsa">Войти в CodeRoute
          </button>
        </div>
      </div>

      <div class="al-center">Еще нет аккаунта? <a class="link" title="" @click="openRegistrationModal">Зарегистрироваться</a>
      </div>
    </form>
  </div>
</template>
