<script setup>

</script>

<template>

  <div class="flexibleY gapMedium">
    <div class="flexibleY gapXSmallest">
      <h6 class="fn-subcap"><b>Отслеживание прогресса</b></h6>
      <p class="lhMain">Для отслеживания прогресса обновляй статус каждого блока в его меню.</p>
      <p class="lhMain">Все доступные статусы блоков:</p>
      <ul class="borderedList">
        <li class="item flexible gapMini">
          <div class="sSmallest crFormItem radRound secondary2 filled"></div>
          <div>Пропустил</div>
        </li>
        <li class="item flexible gapMini">
          <div class="sSmallest crFormItem radRound primary"></div>
          <div>Не изучаю</div>
        </li>
        <li class="item flexible gapMini">
          <div class="sSmallest crFormItem radRound primary filled"></div>
          <div>В процессе</div>
        </li>
        <li class="item flexible gapMini">
          <div class="sSmallest crFormItem radRound completed filled"></div>
          <div>Изучил</div>
        </li>
      </ul>
    </div>
  </div>
</template>
