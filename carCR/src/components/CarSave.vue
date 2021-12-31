<template>
    <div>
        <b-form @submit.stop.prevent @submit="onSubmit">
            <b-container class="mt-3">
                <b-row class="justify-content-md-center">
                    <b-col md="6">
                        <h4>Syötä ajoneuvon tiedot</h4>
                    </b-col>
                </b-row>
                <b-row class="mt-2 justify-content-md-center">
                    <b-col md="6">
                        <label for="car-manufacturer" class="inputLabel">Valmistaja</label>
                        <b-form-input type="text" v-model="carMake" :state="validationMake" id="car-manufacturer" required></b-form-input>
                        <b-form-invalid-feedback :state="validationMake">
                            Auton valmistajan tulee olla 2-100 merkkiä pitkä.
                        </b-form-invalid-feedback>
                        <b-form-valid-feedback :state="validationMake">
                            Auton valmistaja ok
                        </b-form-valid-feedback>
                    </b-col>
                </b-row>
                <b-row class="mt-2 justify-content-md-center">
                    <b-col md="6">
                        <label for="car-model" class="inputLabel">Malli</label>
                        <b-form-input type="text" v-model="carModel" :state="validationModel" id="car-model" required></b-form-input>
                        <b-form-invalid-feedback :state="validationModel">
                            Auton mallin tulee olla 2-100 merkkiä pitkä.
                        </b-form-invalid-feedback>
                        <b-form-valid-feedback :state="validationModel">
                            Auton malli ok
                        </b-form-valid-feedback>
                    </b-col>
                </b-row>
                <b-row class="mt-2 justify-content-md-center">
                    <b-col md="6">
                        <label for="car-date" class="inputLabel">Vuosimalli</label>
                        <b-form-input type="number" v-model="carDate" :state="validationDate" id="car-date" required></b-form-input>
                        <b-form-invalid-feedback :state="validationDate">
                            Syötä kelvollinen vuosimalli
                        </b-form-invalid-feedback>
                        <b-form-valid-feedback :state="validationDate">
                            Vuosimalli ok
                        </b-form-valid-feedback>
                    </b-col>
                </b-row>
                <b-row class="mt-3 justify-content-md-center">
                    <b-col md="6">
                        <b-button type="submit" variant="primary">Tallenna</b-button>
                    </b-col>
                </b-row>
                <b-row class="mt-2 justify-content-md-center">
                    <b-col md="6">
                        <b-button type="" variant="secondary">Takaisin</b-button>
                    </b-col>
                </b-row>
            </b-container>
        </b-form>
</div>
</template>

<script>
  export default {
    data() {
      return {
          carMake: '',
          carModel: '',
          carDate: ''
      }
        },
        methods: {
            onSubmit(event) {
                event.preventDefault()
                alert(JSON.stringify("Merkki: " + this.carMake + " Malli:" + this.carModel + " Vuosimalli: " + this.carDate))
            }
        },
    computed: {
      validationMake() {
            return this.carMake.length > 2 && this.carMake.length < 100
        },
        validationModel() {
            return this.carModel.length > 2 && this.carModel.length < 100
        },
        validationDate() {
            return this.carDate.length === 4
        }
    }
  }
</script>

<style scoped>
    .inputLabel {
        font-weight: bold;
    }
</style>
