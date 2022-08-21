<template>
  <div>
    <h3 class="mx-5 mt-3" v-if="isCreateAction">Crear Donacion</h3>
    <h3 class="mx-5 mt-3" v-if="isShowAction">Consulta la Donacion</h3>
    <h3 class="mx-5 mt-3" v-if="isEditAction">Editar la Donacion</h3>
  </div>
  <div class="row border border-2 rounded shadow mx-5 my-3 p-4">
    <div class="col-md-6">
      <label class="form-label"
        >Nombre Completo <span class="text-danger">*</span></label
      >
      <input
        type="text"
        class="form-control"
        v-model="entity.patientFullName"
        :disabled="isShowAction"
      />
    </div>
    <div class="col-md-6">
      <label class="form-label"
        >Cantidad de Sangre <span class="text-danger">*</span></label
      >
      <input
        type="number"
        class="form-control"
        v-model="entity.quantityOfBlood"
        :disabled="isShowAction"
      />
    </div>
    <div class="col-md-6">
      <label class="form-label"
        >Tipo de Sangre <span class="text-danger">*</span></label
      >
      <select
        class="form-select"
        v-model="entity.bloodType"
        :disabled="isShowAction"
      >
        <option value="A positivo (A +)">A positivo (A +)</option>
        <option value="A negativo (A-)">A negativo (A-)</option>
        <option value="B positivo (B +)">B positivo (B +)</option>
        <option value="B negativo (B-)">B negativo (B-)</option>
        <option value="AB positivo (AB+)">AB positivo (AB+)</option>
        <option value="AB negativo (AB-)">AB negativo (AB-)</option>
        <option value="O positivo (O+)">O positivo (O+)</option>
        <option value="O negativo (O-)">O negativo (O-)</option>
      </select>
    </div>
    <div class="col-md-12">
      <label class="form-label"
        >Descripcion <span class="text-danger">*</span></label
      >
      <textarea
        type="text"
        class="form-control"
        v-model="entity.description"
        :disabled="isShowAction"
      />
    </div>
    <div class="col-md-3" style="margin-top: 33px" v-if="isCreateAction">
      <button
        class="btn btn-primary form-control"
        @click="createEntity()"
        :disabled="isShowAction"
      >
        Guardar
      </button>
    </div>
    <div class="col-md-3" style="margin-top: 33px" v-if="isEditAction">
      <button
        class="btn btn-primary form-control"
        @click="editEntity()"
        :disabled="isShowAction"
      >
        Guardar Cambios
      </button>
    </div>
  </div>
</template>

<script>
import sellPointApi from "@/api/sellPointApi";
export default {
  name: "EntitesCreateOrEdit",
  data() {
    return {
      errorList: [],
      entity: {
        id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        patientFullName: null,
        quantityOfBlood: 0,
        bloodType: null,
        description: null,
      },
    };
  },
  created() {
    if (this.isCreateAction == false) {
      this.getEntityById();
    }
  },
  computed: {
    isShowAction() {
      return this.$route.query.action == "showRecords" ? true : false;
    },
    isEditAction() {
      return this.$route.query.action == "editRecord" ? true : false;
    },
    isCreateAction() {
      return this.$route.query.action == "createRecord" ? true : false;
    },
  },
  methods: {
    clearForm() {
      this.errorList = [];
      this.entity = {
        id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        patientFullName: null,
        quantityOfBlood: 0,
        bloodType: null,
        description: null,
      };
    },
    async getEntityById() {
      let id = this.$route.params.id;
      let response = await sellPointApi
        .get(`/BloodDonations/${id}`)
        .then((resp) => {
          console.log(resp);
          if (this.isShowAction || this.isEditAction) {
            this.entity = resp.data;
          }
        })
        .catch((err) => {
          this.$swal.fire({
            icon: "error",
            title: "Oops...",
            text: err,
          });
        });
    },
    async createEntity() {
      this.errorList = [];
      console.log(this.entity.id);

      let response = await sellPointApi
        .post("/BloodDonations", this.entity)
        .then((resp) => {
          if (resp.status == 200) {
            this.$swal({
              icon: "success",
              title: "Notificación",
              text: "La Donacion ha sigo guardada correctamente.",
            });
            this.clearForm();
          }
        })
        .catch((err) => {
          const response = err.response.data.errors;
          for (const property in response) {
            this.errorList.push(`${response[property]}`);
          }
          this.$swal.fire({
            icon: "error",
            title: "Oops...",
            html: `<ul>${this.errorList.map(
              (error) => "<li>" + error + "</li>"
            )}</ul>`,
          });
        });
    },
    async editEntity() {
      this.errorList = [];
      parseInt(this.entity.numeroDocumento);
      let response = await sellPointApi
        .put("/BloodDonations", this.entity)
        .then((resp) => {
          console.log(resp);
          if (resp.status == 200) {
            this.$swal({
              icon: "success",
              title: "Notificación",
              text: "La Donacion ha sigo editada correctamente.",
            });
            this.clearForm();
          }
        })
        .catch((err) => {
          const response = err.response.data.errors;
          for (const property in response) {
            this.errorList.push(`${response[property]}`);
          }
          this.$swal.fire({
            icon: "error",
            title: "Oops...",
            html: `<ul>${this.errorList.map(
              (error) => "<li>" + error + "</li>"
            )}</ul>`,
          });
        });
    },
  },
};
</script>

<style scoped></style>
