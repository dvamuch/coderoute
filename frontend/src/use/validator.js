import {ref} from "vue";

export default function useValidator() {

  const notifications = ref([]);
  const isValid = ref(null);

  const validate = (formData, rules) => {
    notifications.value = [];
    let newIsValidObject = {};
    for (let property in formData.value) {
      newIsValidObject[property] = true;
    }

    for (let {rule, fieldName, notification} of rules) {
      if (!rule(formData.value[fieldName])) {
        notifications.value.push(notification);
        newIsValidObject[fieldName] = false;
      }
    }

    isValid.value = newIsValidObject;
  };

  return {validate, notifications, isValid};
}
