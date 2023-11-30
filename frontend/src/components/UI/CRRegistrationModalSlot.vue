<script setup>

</script>

<template>
  <div class="flexibleY gapMedium">
    <h6 class="fn-subcap al-center"><b>Создать аккаунт</b></h6>

    <form class="flexibleY gapSmall">


      <div class="flexible gapSmaller">
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
