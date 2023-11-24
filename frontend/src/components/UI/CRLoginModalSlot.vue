<script setup>
import {computed, ref} from "vue";

const isShowingPassword = ref(false);
const visibilityIconStyle = computed(() => {
  return isShowingPassword.value ? "--crMsk: url('/icons/visibility_on.svg');" : "--crMsk: url('/icons/visibility_off.svg');";
});
const inputTypeForPassword = computed(() => {
  return isShowingPassword.value ? "text" : "password";
});

const reverseShowingPassword = () => {
  isShowingPassword.value = !isShowingPassword.value;
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
          <label class="crFormWrap">
            <input type="text" placeholder="EMail или логин" class="crFormItem txt secondary hMedium radSmall"/>
            <span class="crFormPlaceholder">EMail или логин</span>
          </label>

          <label class="crFormWrap">
            <input :type="inputTypeForPassword" placeholder="Пароль"
                   class="crFormItem txt secondary hMedium radSmall"/>
            <span class="crFormPlaceholder">Пароль</span>
            <span class="crFormIcon right">
                  <span @click="reverseShowingPassword" class="crIcon sMedium" :style="visibilityIconStyle"></span>
                </span>
          </label>
        </div>
      </div>

      <div class="flexibleY gapSmaller">
        <div class="al-center fn-alert">Неверный email или пароль</div>
        <div class="flexible gapSmallest">
          <button type="submit" class="crFormItem button secondary filled hLarge radRound grow">Забыл(а) пароль?
          </button>
          <button class="crFormItem button primary filled hLarge radRound grow">Войти в CodeRoute</button>
        </div>
      </div>

      <div class="al-center">Еще нет аккаунта? <a class="link" title="" href="#">Зарегистрироваться</a></div>
    </form>
  </div>
</template>
