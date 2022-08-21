<template>
  <div class="m-5">
    <div class="d-flex justify-content-between my-4">
      <div>
        <h3>Listado de Donaciones de Sangre</h3>
      </div>
      <div>
        <button
          class="btn btn-primary"
          style="width: 150px"
          @click="createEntity()"
        >
          Crear <i class="fa fa-plus"></i>
        </button>
      </div>
    </div>
    <vue-good-table
      :columns="columns"
      :rows="rows"
      :search-options="{ enabled: true }"
      :pagination-options="{
        enabled: true,
        mode: 'records',
      }"
    >
      <template #table-row="props">
        <span v-if="props.column.field == 'action'">
          <button
            class="btn btn-primary"
            size="sm"
            @click="showEntity(props.row)"
          >
            <i class="fas fa-eye"></i>
          </button>
          <button
            class="btn btn-danger mx-2"
            size="sm"
            @click="removeEntity(props.row)"
          >
            <i class="fas fa-trash"></i>
          </button>
          <button
            class="btn btn-warning"
            size="sm"
            @click="editEntity(props.row)"
          >
            <i class="fas fa-edit"></i>
          </button>
        </span>
        <span v-else>
          {{ props.formattedRow[props.column.field] }}
        </span>
      </template>
    </vue-good-table>
  </div>
</template>

<script>
import sellPointApi from "@/api/sellPointApi";
export default {
  name: "EntitiesListPages",
  created() {
    this.getEntitiesRecords();
  },
  data() {
    return {
      columns: [
        {
          label: "Paciente",
          field: "patientFullName",
        },
        {
          label: "Tipo de Sangre",
          field: "bloodType",
        },
        {
          label: "Cantidad de Sangre",
          field: "quantityOfBlood",
        },
        {
          label: "Descripcion",
          field: "description",
        },
        {
          label: "Acciones",
          field: "action",
        },
      ],
      rows: [],
    };
  },
  methods: {
    async getEntitiesRecords() {
      let response = await sellPointApi
        .get("/BloodDonations")
        .then((resp) => {
          this.rows = resp.data;
        })
        .catch((err) => {
          this.$swal.fire({
            icon: "error",
            title: "Oops...",
            text: err,
          });
        });
    },
    createEntity() {
      this.$router.push({
        name: "blood-donation-create",
        query: { action: "createRecord" },
      });
    },
    showEntity(data) {
      const entity = { ...data };
      const id = entity.id;
      this.$router.push({
        name: "blood-donation-show",
        params: { id: id },
        query: { action: "showRecords" },
      });
    },
    editEntity(data) {
      const entity = { ...data };
      const id = entity.id;
      this.$router.push({
        name: "blood-donation-edit",
        params: { id: id },
        query: { action: "editRecord" },
      });
    },
    async removeEntity(data) {
      const entity = { ...data };
      const id = entity.id;
      let response = await sellPointApi
        .delete(`/BloodDonations/${id}`)
        .then((resp) => {
          if (resp.status == 200) {
            this.$swal({
              icon: "success",
              title: "Notificación",
              text: resp.data,
            });
            this.getEntitiesRecords();
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
  },
};
</script>

<style></style>
