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
                        <b-form-input type="text" v-model="carForm.carMake" :state="validationMake" id="car-manufacturer" required></b-form-input>
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
                        <b-form-input type="text" v-model="carForm.carModel" :state="validationModel" id="car-model" required></b-form-input>
                        <b-form-invalid-feedback :state="validationModel">
                            Auton mallin tulee olla 1-100 merkkiä pitkä.
                        </b-form-invalid-feedback>
                        <b-form-valid-feedback :state="validationModel">
                            Auton malli ok
                        </b-form-valid-feedback>
                    </b-col>
                </b-row>
                <b-row class="mt-2 justify-content-md-center">
                    <b-col md="6">
                        <label for="car-date" class="inputLabel">Vuosimalli</label>
                        <b-form-input type="number" v-model="carForm.carDate" :state="validationDate" id="car-date" required></b-form-input>
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
                        <b-button type="submit" variant="primary" v-if="notAdded">Tallenna</b-button>
                        <div v-else>
                            <b-spinner label="Loading..."></b-spinner>
                        </div>
                    </b-col>
                </b-row>
                <!--<b-row class="mt-2 justify-content-md-center">
                    <b-col md="6">
                        <b-button type="" variant="secondary">Takaisin</b-button>
                    </b-col>
                </b-row>-->
            </b-container>
        </b-form>
    </div>
</template>

<script>
    export default {
        name: 'CarSave',
        data() {
            return {
                carForm: {
                    carMake: '',
                    carModel: '',
                    carDate: '',
                },
                notAdded: true,

            }
        },
        methods: {
            onSubmit(event) {
                if (this.validationModel && this.validationDate && this.validationMake) {
                    event.preventDefault();
                    //getting spinner where the save-button was
                    this.notAdded = false;
                    //we can call a function from CarList.vue mounted() like this and pass the data we want to add
                    this.$root.$emit('CarListHideAndRefresh', this.carForm) }
                else {
                    alert("Ole hyvä ja tarkista lisättävän ajoneuvon tiedot!");
                }
            },
        },
        computed: {
            //INPUT VALIDATIONS
            //car make cannot be under 2 and over 100 char
            validationMake() {
                return this.carForm.carMake.length >= 2 && this.carForm.carMake.length <= 100
            },
            //car model cannot be under 1 and over 100 char
            validationModel() {
                return this.carForm.carModel.length >= 1 && this.carForm.carModel.length <= 100
            },
            validationDate() {
                //car manufacture date cannot be under 1900 and not over current year
                var dateNow = new Date().getFullYear();
                return this.carForm.carDate.length === 4 && this.carForm.carDate >= 1900 && this.carForm.carDate <= dateNow
            }
        }
    }
</script>

<style scoped>
    .inputLabel {
        font-weight: bold;
    }
</style>
