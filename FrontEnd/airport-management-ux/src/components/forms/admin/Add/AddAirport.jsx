import React, { Component } from "react";
import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPlaneDeparture } from "@fortawesome/free-solid-svg-icons";
import "../../../../styles/forms/addFlight.scss";
import {
  getCountries,
  saveAirport,
  getAirport
} from "../../../../services/airportService";
//resources
import data from "../../../../resources/content.json";
//common templates
import Input from "../../../common/forms/input";
import Select from "../../../common/forms/select";
import airportSchema from "../../../../schemas/airportSchema";

export default class AddAirport extends Component {
  state = {
    dataForm: {
      name: "",
      country: "",
      city: ""
    },
    updateForm: false,
    newlistOfCountries: [{ id: "", name: "" }],

    errors: {}
  };

  validate = () => {
    const dataForm = { ...this.state.dataForm };
    const errorMessage = {};
    const options = { abortEarly: false };
    const { error } = airportSchema.validate(
      {
        name: dataForm.name,
        country: dataForm.country,
        city: dataForm.city
      },
      options
    );

    if (!error) return null;
    for (let item of error.details) {
      errorMessage[item.path[0]] = item.message;
    }
    this.setState({ errors: errorMessage });
  };

  add = async () => {
    const airport = {
      name: this.state.dataForm.name,
      country: this.state.dataForm.country,
      city: this.state.dataForm.city
    };
    saveAirport(airport);
  };

  update = async () => {
    const airport = {
      id: this.props.match.params.id,
      name: this.state.dataForm.name,
      country: this.state.dataForm.country,
      city: this.state.dataForm.city
    };
    saveAirport(airport);
  };

  handleSubmit = e => {
    e.preventDefault();
    this.validate();
    if (this.state.updateForm === false) this.add();
    else {
      this.update();
    }
  };

  createListOfCountries = listOfCountries => {
    var newlistOfCountries = [{ id: "", name: "" }];
    listOfCountries.map(item => {
      var myobj = { id: item.name.toLowerCase(), name: item.name };
      newlistOfCountries.push(myobj);
    });
    return newlistOfCountries;
  };
  async swtichToUpdate(airportId) {
    if (airportId !== undefined) this.setState({ updateForm: true });
    if (this.state.updateForm !== false) {
      const { data: airportDetails } = await getAirport(airportId);
      this.setState({ dataForm: this.mapToViewModel(airportDetails) });
    }
  }

  async componentDidMount() {
    const { data: listOfCountries } = await getCountries();
    const newlistOfCountries = this.createListOfCountries(listOfCountries);
    this.setState({ newlistOfCountries });
    const airportId = this.props.match.params.id;
    this.swtichToUpdate(airportId);
  }

  mapToViewModel(airport) {
    return {
      name: airport.name,
      country: airport.country,
      city: airport.city
    };
  }

  handleClick = e => {
    e.preventDefault();
    this.setState({
      dataForm: {
        name: "",
        country: "",
        city: ""
      }
    });
  };

  handleChange = ({ currentTarget: input }) => {
    const dataForm = { ...this.state.dataForm };
    dataForm[input.name] = input.value;
    this.setState({ dataForm });
  };

  render() {
    const { dataForm, errors, updateForm } = this.state;

    return (
      <div className="form-inner-content">
        <div className="header-section-wrapper">
          <div className="icon">
            <FontAwesomeIcon icon={faPlaneDeparture} color="#763626" />
          </div>
          <div className="title">{data.airport.title}</div>
        </div>
        <form onSubmit={this.handleSubmit}>
          <Input
            name={data.airport.name.name}
            label={data.airport.name.label}
            value={dataForm.name}
            onChange={this.handleChange}
            error={errors.name}
            rowType="odd"
          />
          <Select
            name={data.airport.country.name}
            label={data.airport.country.label}
            value={dataForm.country}
            onChange={this.handleChange}
            options={this.state.newlistOfCountries}
            error={errors.country}
          />
          <Input
            name={data.airport.city.name}
            label={data.airport.city.label}
            value={dataForm.city}
            onChange={this.handleChange}
            error={errors.city}
            rowType="odd"
          />

          <div className="bottom-section-wrapper">
            <button className="add-flight">
              {updateForm
                ? data.airport.updateButton.name
                : data.airport.submitButton.name}
            </button>
            <Link to="/admin/airports">
              <button className="back-button">
                {data.airport.backButton.name}
              </button>
            </Link>
          </div>
        </form>
      </div>
    );
  }
}
