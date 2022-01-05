<template>
    <div>
        <b-container>
            <b-row class="mb-3">
                <b-col class="float-start"><h4>Tietokannassa olevat ajoneuvot</h4></b-col>
                <b-col><b-button v-b-modal.carSaveModal variant="primary" class="float-end">Lisää ajoneuvo</b-button></b-col>
            </b-row>
            <b-table id="carTable"
                     hover
                     :items="carsFromDb"
                     :fields="fields"
                     thead-class="bg-light"
                     selectable
                     select-mode="single"
                     @row-clicked="deleteCar"
                     >

            </b-table>
            <h3 v-if="errorMsg != ''" class="text-danger">{{errorMsg}}</h3>
            <p class="text-secondary">*Voit lajitella ajoneuvot klikkaamalla haluttua otsikkoa.</p>
            <p class="text-secondary">*Voit poistaa ajoneuvoja tietokannasta klikkaamalla ajoneuvoa.</p>
        </b-container>
        <b-modal id="carSaveModal" size="xl" hide-footer title="Ajoneuvon lisäys tietokantaan">
            <CarSave />
        </b-modal>
    </div>
</template>

<script>
    import CarSave from './CarSave.vue'
    import ApiCall from "../api/ApiCallService";

    export default {
        name: 'CarList',
        components: {
            CarSave,
        },
        data() {
            return {
                //HOX! carId field is hidden from the user
                fields: [
                    {
                        key: 'carMake',
                        label: 'Valmistaja',
                        sortable: true
                    },
                    {
                        key: 'carModel',
                        label: 'Malli',
                        sortable: true
                    },
                    {
                        key: 'carDate',
                        label: 'Vuosimalli',
                        sortable: true,
                    }
                ],
                carsFromDb: [],
                errorMsg: "",
            }
        },
        mounted() {
            this.loadCars();
            this.$root.$on('CarListHideAndRefresh', (carForm) => {
                this.addCar(carForm);
                this.$bvModal.hide('carSaveModal');
            });
        },
        watch: {
            carsFromDb: {
                handler() {
                    this.loadCars();
                }
            }
        },
        methods: {
            //Getting all the cars in the DB to list array
            loadCars() {
                ApiCall.loadCars()
                    .then((response) => {
                        //console.log(response.data)
                        //populatin cars 'array'
                        this.carsFromDb = response.data;
                    })
                    .catch((error) => {
                        //console.log(error)
                        this.errorMsg = 'Ajoneuvojen haku tietokannasta epäonnistui' + error;
                    })
            },
            //Adding a car from database
            addCar(car) {
                ApiCall.addCar(car)
                    .then(/*response => console.log(response)*/)
                    .catch((error) => {
                    this.errorMsg = 'Ajoneuvon tallennus tietokantaan epäonnistui' + error;
                })
                //alert(JSON.stringify("Lisätty auto Merkki: " + this.carForm.carMake + " Malli:" + this.carForm.carModel + " Vuosimalli: " + this.carForm.carDate))
            },
            //Deleting a car from database
            deleteCar(row) {
                //fast confirmation car delete
                if (confirm('Haluatko varmasti poistaa ajoneuvon:\n' + 'AjoneuvoId: ' + row.carId + '\nMerkki:' + row.carMake + '\nMalli:' + row.carModel + '?')) {
                    ApiCall.deleteCar(row)
                        .then(/*response => console.log(response)*/)
                        .catch((error) => {
                            this.errorMsg = 'Ajoneuvon poisto tietokannasta epäonnistui' + error;
                        })
                }
            },
        },
    }
</script>

<style scoped>
    /*Hiding the default sorting values*/
    ::v-deep .sr-only {
        display: none !important
    }
</style>