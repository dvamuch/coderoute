<script setup>

import CRPasswordInput from "@/components/UI/CRPasswordInput.vue";
import CRTextInput from "@/components/UI/CRTextInput.vue";
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
          <CRTextInput placeholder="Email или логин"></CRTextInput>

          <CRPasswordInput></CRPasswordInput>
        </div>
      </div>

      <div class="flexibleY gapSmaller">
        <!--        <div class="al-center fn-alert">Неверный email или пароль</div>-->
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
