import React from "react";
import FullCalendar from '@fullcalendar/react'
import dayGridPlugin from '@fullcalendar/daygrid'
import interactionPlugin from '@fullcalendar/interaction'

function BigCalendar (props){
    return (
      <div className="card">
        <div className="py-3 px-3">
          <FullCalendar
            plugins={[dayGridPlugin, interactionPlugin]}
            editable={true}
            eventDrop={props.handleEventDrop}
            eventClick={props.handleEventClick}
            events='https://fullcalendar.io/demo-events.json'
          />
        </div>
      </div>
    );
  }


export default BigCalendar;