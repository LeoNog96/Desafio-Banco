<template>
  <div class="text-center">
    <v-dialog v-model="modal.dialog" width="800">
      <v-card>
        <v-card-title class="text-h5 grey lighten-2">
          Realizar Login
        </v-card-title>

        <v-container fluid fill-height>
          <v-layout align-center justify-center>
            <v-form>
              <v-text-field
                name="login"
                label="Email"
                type="email"
                v-model="login.email"
                prepend-icon="mdi-account"
              ></v-text-field>
              <v-text-field
                id="password"
                name="senha"
                label="Senha"
                v-model="login.senha"
                prepend-icon="mdi-lock"
                type="password"
              ></v-text-field>
            </v-form>
          </v-layout>
        </v-container>

        <v-divider></v-divider>

        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="primary" text @click="modal.dialog = false">
            entrar
          </v-btn>
          <v-btn color="error" text @click="modal.dialog = false"> sair </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script>
export default {
  data: () => ({
    login: {
      email: "",
      senha: "",
    },
  }),
  props: ["modal"],
};
</script>
