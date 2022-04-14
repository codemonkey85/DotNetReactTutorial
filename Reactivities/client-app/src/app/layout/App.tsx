import React, { Fragment, useEffect, useState } from "react";
import "./styles.css";
import axios from "axios";
import { Activity } from "../models/activity";
import NavBar from "./NavBar";
import ActivityDashboard from "../../features/activities/dashboard/ActivityDashboard";
import { Col, Container } from "react-bootstrap";
import ActivityDetails from "../../features/activities/details/ActivityDetails";

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);
  useEffect(() => {
    axios
      .get<Activity[]>("https://localhost:7147/api/activities")
      .then((response) => setActivities(response.data));
  }, []);

  return (
    <>
      <NavBar />
      <ActivityDashboard activities={activities} />
    </>
  );
}

export default App;
