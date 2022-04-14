import React from "react";
import { Col, Container, Row } from "react-bootstrap";
import { Activity } from "../../../app/models/activity";
import ActivityDetails from "../details/ActivityDetails";
import ActivityForm from "../form/ActivityForm";
import ActivityList from "./ActivityList";

interface Props {
  activities: Activity[];
  selectedActivity: Activity | undefined;
  selectActivity: (id: string) => void;
  cancelSelectActivity: () => void;
  editMode: boolean;
  openForm: (id: string) => void;
  closeForm: () => void;
}

export default function ActivityDashboard({
  activities,
  selectedActivity,
  selectActivity,
  cancelSelectActivity,
  editMode,
  openForm,
  closeForm,
}: Props) {
  return (
    <Container fluid>
      <Row>
        <Col sm={8}>
          <ActivityList
            activities={activities}
            selectedActivity={selectedActivity}
            selectActivity={selectActivity}
            cancelSelectActivity={cancelSelectActivity}
          />
        </Col>
        <Col sm={4}>
          {selectedActivity && !editMode && (
            <ActivityDetails
              activity={selectedActivity}
              cancelSelectActivity={cancelSelectActivity}
              openForm={openForm}
            />
          )}
          {editMode && (
            <ActivityForm closeForm={closeForm} activity={selectedActivity} />
          )}
        </Col>
      </Row>
    </Container>
  );
}
