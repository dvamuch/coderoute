import {useAuthorizationStore} from "@/stores/authorization";
import {computed} from "vue";


export default function userFetcher() {
  const authorizationStore = useAuthorizationStore();
  const jwtToken = computed(() => authorizationStore.jwtToken);
  const isAuthorized = computed(() => authorizationStore.isAuthorized);

  const fetchJson = async (url, options = {}) => {

    // console.log(isAuthorized.value)

    if (isAuthorized.value) {
      options.headers = {
        Authorization: `Bearer ${jwtToken.value}`,
      };
    }

    let result = await fetch(url, options);

    if (result.status === 400) {
      authorizationStore.deauthenticateUser();
      options.headers = {};
      result = await fetch(url, options);
    }

    return await result.json();
  };

  return {
    fetchJson,
  };
}
