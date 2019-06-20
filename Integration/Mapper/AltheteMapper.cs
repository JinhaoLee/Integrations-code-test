using AutoMapper;
using Integration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration {
    class AltheteMapper {
        public static IMapper getMapper() {
            var config = new MapperConfiguration(
                        cfg => cfg.CreateMap<Athlele, AthleleDTO>()
                            .ForMember(d => d.row, opt => opt.MapFrom(u => u.id))
                            .ForMember(d => d.pairs, opt => opt.MapFrom(
                                u => new List<PairDTO> {
                                        new PairDTO{ key="firstName", value=u.firstName },
                                        new PairDTO{ key="lastName", value=u.lastName },
                                        new PairDTO{ key="middleName", value=u.middleName },
                                        new PairDTO{ key="dateOfBirth", value=u.dateOfBirth },
                                        new PairDTO{ key="sex", value=u.sex },
                                        new PairDTO{ key="height", value=u.height },
                                        new PairDTO{ key="sport", value=u.sport }
                                    }
                                )
                            )
                         );

            return config.CreateMapper();
        }
    }
}
