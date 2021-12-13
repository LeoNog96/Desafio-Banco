<template>
  <v-container>
    <v-row class="text-center">
      <v-col cols="12">
        <v-img
          :src="require('../assets/logo.svg')"
          class="my-3"
          contain
          height="200"
        />
      </v-col>

      <v-col class="mb-4">
        <h1 class="display-2 font-weight-bold mb-3">Banco</h1>
      </v-col>

      <v-col class="mb-5" cols="12">
        <v-row justify="center">
          <v-btn x-large color="success" dark> Criar Conta </v-btn>
        </v-row>
      </v-col>
      <v-col class="mb-5" cols="12">
        <v-row justify="center">
          <v-btn x-large color="primary" dark @click="modalLogin.dialog = true">
            Entrar
          </v-btn>
        </v-row>
      </v-col>
    </v-row>
    <LoginModal :modal="modalLogin"></LoginModal>
  </v-container>
</template>

<script>
import LoginModal from "./modal/LoginModal.vue";

export default {
  name: "HelloWorld",
  components: {
    LoginModal,
  },
  data: () => ({
    modalLogin: {
      dialog: false,
    },
  }),
};
</script>
