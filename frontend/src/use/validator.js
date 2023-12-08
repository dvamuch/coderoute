import {ref} from "vue";

export default function useValidator() {

  const notifications = ref({});
  const isValid = ref(null);
  const isOk = ref(true);

  const validate = (formData, rules) => {
    notifications.value = {};
    isOk.value = true;
    let newIsValidObject = {};
    for (let property in formData.value) {
      newIsValidObject[property] = true;
    }

    for (let {rule, fieldNames, notification} of rules) {
      let isRuleOk = true;
      for (let fieldName of fieldNames) {
        if (!rule(formData.value[fieldName])) {
          newIsValidObject[fieldName] = false;
          isRuleOk = false;
        }
      }

      if (!isRuleOk) {
        notifications.value[notification] = true;
        isOk.value = false;
      }
      // for (let fieldName of fieldNames){
      //   if (!rule(formData.value[fieldName])) {
      //     notifications.value.push(notification);
      //     newIsValidObject[fieldName] = false;
      //   }
      // }
    }

    isValid.value = newIsValidObject;
  };

  return {validate, notifications, isValid, isOk};
}
