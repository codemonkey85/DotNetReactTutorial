import React from "react";
import { Col, Container, Row } from "react-bootstrap";
import { Activity } from "../../../app/models/activity";
import ActivityDetails from "../details/ActivityDetails";
import ActivityList from "./ActivityList";

interface Props {
  activities: Activity[];
}

export default function ActivityDashboard({ activities }: Props) {
  return (
    <>
      <Container>
        <Row>
          <Col>
            <ActivityList activities={activities} />
          </Col>
          <Col>
            <ActivityDetails activity={activities[0]} />
          </Col>
        </Row>
      </Container>
    </>
  );
}
