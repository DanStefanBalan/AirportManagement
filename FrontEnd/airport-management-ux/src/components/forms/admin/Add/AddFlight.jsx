import React, { Component } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPlaneDeparture } from "@fortawesome/free-solid-svg-icons";
import "../../../../styles/forms/addFlight.scss";
//resources
import minutes from "../../../../resources/images/min.png";
import hours from "../../../../resources/images/hr.png";
import data from "../../../../resources/content.json";
//common templates
import Input from "../../../common/forms/input";
import DoubleInput from "../../../common/forms/doubleinput";
import Select from "../../../common/forms/select";
//Schemas
import flightSchema from "../../../../schemas/flightSchema";

export default class AddFlight extends Component {
  state = {
    dataForm: {
      flightNumber: "",
      aircraft: "",
      destination: "",
      estimationHoursTime: "",
      estimationMinutesTime: "",
      arrivalMinutesTime: "",
      arrivalHoursTime: "",
      departureMinutesTime: "",
      departureHoursTime: "",
      flightMinutesTime: "",
      flightHoursTime: "",
      status: "",
      gate: "",
      airline: ""
    },
    errors: {}
  };

  validate = () => {
    const dataForm = { ...this.state.dataForm };
    const errorMessage = {};
    const options = { abortEarly: false };
    const { error } = flightSchema.validate(
      {
        flightNumber: dataForm.flightNumber,
        aircraft: dataForm.aircraft,
        destination: dataForm.destination,
        estimationHoursTime: dataForm.estimationHoursTime,
        estimationMinutesTime: dataForm.estimationMinutesTime,
        arrivalHoursTime: dataForm.arrivalHoursTime,
        arrivalTimeMinutesTime: dataForm.departureMinutesTime,
        departureHoursTime: dataForm.departureHoursTime,
        departureMinutesTime: dataForm.departureMinutesTime,
        flightHoursTime: dataForm.flightHoursTime,
        flightMinutesTime: dataForm.flightMinutesTime,
        status: dataForm.status,
        gate: dataForm.gate,
        airline: dataForm.airline
      },
      options
    );

    if (!error) return null;
    for (let item of error.details) {
      errorMessage[item.path[0]] = item.message;
    }
    this.setState({ errors: errorMessage });
  };

  handleSubmit = e => {
    e.preventDefault();
    this.validate();
  };

  handleClick = e => {
    e.preventDefault();
    var dataForm = { ...this.state.dataForm };
    dataForm.status.value = "";
    dataForm.flightMinutesTime = "";
    dataForm.flightNumber = "";
    this.setState({ dataForm });
  };

  handleChange = ({ currentTarget: input }) => {
    const dataForm = { ...this.state.dataForm };
    dataForm[input.name] = input.value;
    this.setState({ dataForm });
  };

  setSelectValues = () => {
    return ["", "Value1", "Value2", "Value3", "Value4"];
  };

  render() {
    const coverage = this.setSelectValues();
    const { dataForm, errors } = this.state;

    return (
      <div className="form-inner-content">
        <div className="header-section-wrapper">
          <div className="icon">
            <FontAwesomeIcon icon={faPlaneDeparture} color="#763626" />
          </div>
          <div className="title">{data.flight.title}</div>
        </div>
        <form onSubmit={this.handleSubmit}>
          <Input
            name={data.flight.flightNumber.name}
            label={data.flight.flightNumber.label}
            value={dataForm.flightNumber}
            onChange={this.handleChange}
            error={errors.flightNumber}
            rowType="odd"
          />
          <Select
            name={data.flight.aircraft.name}
            label={data.flight.aircraft.label}
            onChange={this.handleChange}
            options={coverage}
            error={errors.aircraft}
          />
          <Select
            name={data.flight.destination.name}
            label={data.flight.destination.label}
            onChange={this.handleChange}
            options={coverage}
            error={errors.destination}
            rowType="odd"
          />
          <DoubleInput
            label={data.flight.estimationTime.label}
            name1={data.flight.estimationTime.name1}
            name2={data.flight.estimationTime.name2}
            value1={dataForm.estimationHoursTime}
            value2={dataForm.estimationMinutesTime}
            onChange={this.handleChange}
            error1={errors.estimationHoursTime}
            error2={errors.estimationMinutesTime}
            background1={hours}
            background2={minutes}
            type="number"
          />
          <DoubleInput
            label={data.flight.arrivalTime.label}
            name1={data.flight.arrivalTime.name1}
            name2={data.flight.arrivalTime.name2}
            value1={dataForm.arrivalHoursTime}
            value2={dataForm.arrivalMinutesTime}
            onChange={this.handleChange}
            error1={errors.arrivalHoursTime}
            error2={errors.arrivalMinutesTime}
            background1={hours}
            background2={minutes}
            type="number"
            rowType="odd"
          />
          <DoubleInput
            label={data.flight.departureTime.label}
            name1={data.flight.departureTime.name1}
            name2={data.flight.departureTime.name2}
            value1={dataForm.departureHoursTime}
            value2={dataForm.departureMinutesTime}
            onChange={this.handleChange}
            error1={errors.departureHoursTime}
            error2={errors.departureMinutesTime}
            background1={hours}
            background2={minutes}
            type="number"
          />
          <DoubleInput
            label={data.flight.flightTime.label}
            name1={data.flight.flightTime.name1}
            name2={data.flight.flightTime.name2}
            value1={dataForm.flightHoursTime}
            value2={dataForm.flightMinutesTime}
            onChange={this.handleChange}
            error1={errors.flightHoursTime}
            error2={errors.flightMinutesTime}
            background1={hours}
            background2={minutes}
            type="number"
            rowType="odd"
          />
          <Select
            name={data.flight.status.name}
            label={data.flight.status.label}
            onChange={this.handleChange}
            options={coverage}
            error={errors.status}
          />
          <Select
            name={data.flight.gate.name}
            label={data.flight.gate.label}
            onChange={this.handleChange}
            options={coverage}
            error={errors.gate}
            rowType="odd"
          />
          <Input
            name={data.flight.airline.name}
            label={data.flight.airline.label}
            value={dataForm.airline}
            onChange={this.handleChange}
            error={errors.airline}
          />
          <div className="bottom-section-wrapper">
            <button className="add-flight">
              {data.flight.submitButton.name}
            </button>
            <button className="clear-details" onClick={this.handleClick}>
              {data.flight.clearDataButton.name}
            </button>
          </div>
        </form>
      </div>
    );
  }
}
